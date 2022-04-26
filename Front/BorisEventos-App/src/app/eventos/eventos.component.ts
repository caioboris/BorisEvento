import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
public eventosFiltrados: any = [];

  widthImg = 200;
  marginImg = 2;
  showImage = false;
  private _filterList = '';

  public get filterList(){
    return this._filterList;
  }

  public set filter(value : string){
    this._filterList = value;
    this.eventosFiltrados = this._filterList ? this.filterEventos(this._filterList) : this.eventos;
  }

  filterEventos(filterBy: string): any{
      filterBy = filterBy.toLowerCase();
      return this.eventos.filter(
        (evento : { tema: string; local:string}) => evento.tema.toLowerCase().indexOf(filterBy) !== -1 ||
         evento.local.toLowerCase().indexOf(filterBy) !== -1 )
  }

  collapseImage (){
    this.showImage = !this.showImage;
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos():void{

    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => {
        this.eventos = response,
        this.eventosFiltrados = this.eventos
      },
      error => console.log(error)
    );
}
}
