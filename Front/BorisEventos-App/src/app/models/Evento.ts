import { Lote } from "./Lote";
import { Palestrante } from "./Palestrante";
import { RedeSocial } from "./RedeSocial";

export interface Evento {
 
     id : number;
     tema : string;
     local: string;
     qtdPessoas : number;
     imageUrl : string;
     telefone : string;
     email : string;
     dataEvento? : Date;
     redesSociais : RedeSocial[];
     lote :  Lote[];
     palestrantesEventos : Palestrante[];
}
