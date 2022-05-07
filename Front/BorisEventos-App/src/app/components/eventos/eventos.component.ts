import { Component, OnInit, TemplateRef } from '@angular/core';

import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';


import { Evento } from '../../models/Evento';
import { EventoService } from '../../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  modalRef?: BsModalRef;
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];

  public widthImg = 200;
  public marginImg = 2;
  public showImage = false;
  private _filterList = '';

  public get filterList(){
    return this._filterList;
  }

  public set filter(value : string){
    this._filterList = value;
    this.eventosFiltrados = this._filterList ? this.filterEventos(this._filterList) : this.eventos;
  }

  public filterEventos(filterBy: string): Evento[]{
      filterBy = filterBy.toLowerCase();
      return this.eventos.filter(
        (evento : { tema: string; local:string}) => evento.tema.toLowerCase().indexOf(filterBy) !== -1 ||
         evento.local.toLowerCase().indexOf(filterBy) !== -1 )
  }

  public collapseImage (){
    this.showImage = !this.showImage;
  }

  constructor(
    private eventoService : EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
    ) { }

  public ngOnInit(): void {
    this.getEventos();

    this.spinner.show();

    setTimeout(() => {
      this.spinner.hide();
    }, 5000);
  }

  public getEventos():void {
    this.eventoService.getEventos().subscribe({
      next: (eventos : Evento[]) => {
        this.eventos = eventos;
        this.eventosFiltrados = this.eventos;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar Eventos.', 'Ops');
      },
      complete: () => this.spinner.hide()
    });
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('Evento deletado.','Sucesso')
  }

  decline(): void {
    this.modalRef?.hide();
  }

}
