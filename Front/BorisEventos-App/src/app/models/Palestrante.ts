import { Evento } from "./Evento";
import { RedeSocial } from "./RedeSocial";

export interface Palestrante {

    id: number;
    nome: string;
    descricao: string;
    imagemUrl: string;
    telefone: string;
    email: string;
    palestrantesEventos: Evento[];
    redesSociais: RedeSocial[];
}
