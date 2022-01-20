import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ReporteService } from '../services/services/reporte.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  listReportes : any[] = [];
  accion = 'Agregar';
  id: number | undefined;

  constructor(private router: Router, private fb: FormBuilder, private toastr: ToastrService, public _reporteService: ReporteService) { 
    this.form = this.fb.group({
      Proveedor: [''],
      Monto: [''],
      Moneda: [''],
      Fecha: [''],
      Comentario: [''],
    })
  }

  form : FormGroup;

  ngOnInit(): void {
    this.obtenerReportes();
  }

  obtenerReportes() {
    this._reporteService.getListReportes().subscribe(data => {
      console.log(data);
      this.listReportes = data;
    }, error => {
      console.log(error);
    })
  }

  guardarReporte(){
    console.log(this.form)

    const Reportes : any = {
      
      Proveedor: this.form.get('Proveedor')?.value,
      Monto: this.form.get('Monto')?.value,
      Moneda: this.form.get('Moneda')?.value,
      Fecha: this.form.get('Fecha')?.value,
      Comentario: this.form.get('Comentario')?.value
    }
    
    if(this.id == undefined) {
    this._reporteService.saveReporte(Reportes).subscribe(data => {
      this.toastr.success('El reporte fue registrado con exito!', 'Reporte Registrado');
      this.obtenerReportes();
      this.form.reset();
    }, error => {
      this.toastr.error('Opss.. ocurrio un error','Error')
      console.log(error);
    })
  }else {

    Reportes.id = this.id;
    // Editamos tarjeta
    this._reporteService.updateReporte(this.id,Reportes).subscribe(data => {
      this.form.reset();
      this.accion = 'Agregar';
      this.id = undefined;
      this.toastr.info('El Reporte fue actualizado con exito!', 'Reporte Actualizado');
      this.obtenerReportes();
    }, error => {
      console.log(error);
    })

  }
  }

  eliminarReporte(id: number) {
    this._reporteService.deleteReporte(id).subscribe(data => {
      this.toastr.error('El reporte fue eliminada con exito!','Reporte eliminado');
      this.obtenerReportes();
    }, error => {
      console.log(error);
    })

  }

  editarReporte(reporte: any) {
    this.accion = 'Editar';
    this.id = reporte.id;

    this.form.patchValue({
      Proveedor: reporte.proveedor,
      Monto: reporte.monto,
      Moneda: reporte.moneda,
      Fecha: reporte.fecha,
      Comentario: reporte.comentario,
    })
  }


  Logout() {
    localStorage.removeItem('userToken');
    this.router.navigate(['/login']);
  }
}
