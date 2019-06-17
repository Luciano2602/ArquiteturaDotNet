import { StatusUsuarioEnum } from './usuario-usuario.enum';

export class UsuarioViewModel {
    Codigo: number;
    Nome: string;
    Sobrenome: string;
    StatusUsuarioEnum: StatusUsuarioEnum;
    DataNascimento: Date;
}
