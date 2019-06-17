import { NgModule } from '@angular/core';
import { UsuarioComponent } from './usuario.component';
import { HttpClientModule } from '@angular/common/http';
import { UsuerioService } from './usuario.service';

@NgModule({
    declarations: [
        UsuarioComponent
    ],
    imports: [
        HttpClientModule
    ],
    exports: [
        UsuarioComponent
    ],
    providers: [
        UsuerioService
    ]
})
export class UsuarioModule { }
