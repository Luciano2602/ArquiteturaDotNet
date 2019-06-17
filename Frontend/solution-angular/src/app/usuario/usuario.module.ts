import { NgModule } from '@angular/core';
import { UsuarioComponent } from './usuario.component';
import { HttpClientModule } from '@angular/common/http';
import { UsuarioService } from './usuario.service';
import { CommonModule } from '@angular/common';

@NgModule({
    declarations: [
        UsuarioComponent
    ],
    imports: [
        HttpClientModule,
        CommonModule
    ],
    exports: [
        UsuarioComponent
    ],
    providers: [
        UsuarioService
    ]
})
export class UsuarioModule { }
