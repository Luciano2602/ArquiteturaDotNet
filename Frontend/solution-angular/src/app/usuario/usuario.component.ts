import { Component, OnInit } from '@angular/core';
import { UsuerioService } from './usuario.service';
import { UsuarioViewModel } from './usuario.vm';

@Component({
    selector: 'sl-usuario',
    templateUrl: './usuario.component.html'
})
export class UsuarioComponent implements OnInit {
    usuarios: UsuarioViewModel[] = [];

    constructor(private _usuarioService: UsuerioService) { }

    ngOnInit(): void {
        this._usuarioService.ListarTodos().subscribe((result: UsuarioViewModel[]) => {
            this.usuarios = result;
            console.log(this.usuarios);
        });
    }
}
