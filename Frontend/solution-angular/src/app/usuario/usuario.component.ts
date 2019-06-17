import { Component, OnInit } from '@angular/core';
import { UsuarioService } from './usuario.service';
import { UsuarioViewModel } from './usuario.vm';

@Component({
    selector: 'sl-usuario',
    templateUrl: './usuario.component.html'
})
export class UsuarioComponent implements OnInit {
    usuarios: UsuarioViewModel[] = [];

    constructor(private _usuarioService: UsuarioService) { }

    ngOnInit(): void {
        this._usuarioService.ListarTodos().subscribe((usuarios: UsuarioViewModel[]) => {
            this.usuarios = usuarios;
            console.log(this.usuarios);
        });
    }
}
