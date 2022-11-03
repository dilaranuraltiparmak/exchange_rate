import { DovizService } from './services/doviz.service';
import { Component } from '@angular/core';
import { Doviz } from './models/doviz';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Doviz.UI';
  dovizs:Doviz[]=[];
  constructor (private DovizService:DovizService){}


    ngOnInit(): void{
      this.DovizService.getDovizs().subscribe((result:Doviz[]) => (this.dovizs = result));
      }

  }

