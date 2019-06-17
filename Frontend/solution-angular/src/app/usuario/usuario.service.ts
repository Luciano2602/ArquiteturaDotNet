import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UsuarioViewModel } from './usuario.vm';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class UsuerioService {
    private API = 'https://localhost:44386/api/usuario';

    constructor(private http: HttpClient) { }

    ListarTodos(): Observable<UsuarioViewModel[]> {
        return this.http.get<UsuarioViewModel[]>(this.API);
    }
}
