import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UsuarioViewModel } from './usuario.vm';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class UsuarioService {
    private API =  `${environment.API}/usuario`;

    constructor(private http: HttpClient) { }

    ListarTodos(): Observable<UsuarioViewModel[]> {
        return this.http.get<UsuarioViewModel[]>(this.API);
    }
}
