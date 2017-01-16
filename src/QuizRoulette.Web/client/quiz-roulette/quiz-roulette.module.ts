import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { appRoutes } from './quiz-roulette.routes';

import { QuizRouletteComponent } from './quiz-roulette.component';
import { HelloWorldComponent } from './hello-world/hello-world.component';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        RouterModule.forRoot(appRoutes)
    ],
    declarations: [
        HelloWorldComponent,
        QuizRouletteComponent
    ],
    bootstrap: [QuizRouletteComponent]
})
export class QuizRouletteModule { }
