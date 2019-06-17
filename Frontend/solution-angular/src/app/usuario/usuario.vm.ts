import { StatusUsuarioEnum } from './usuario-usuario.enum';

export class UsuarioViewModel {
    codigo: number;
    nome: string;
    sobrenome: string;
    status: StatusUsuarioEnum;
    dataNascimento: Date;
}
