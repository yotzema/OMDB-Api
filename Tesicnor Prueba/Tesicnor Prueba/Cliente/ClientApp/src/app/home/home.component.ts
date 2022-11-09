import { Component,OnInit, OnDestroy} from '@angular/core';
import { EmpleadoService as FilmService } from '../services/FilmService';
import { IFilm } from '../services/Film';
import { Subscription } from 'rxjs';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit,OnDestroy {

  public sub!: Subscription;

  errorMessage: string = '';

  films: IFilm[];

  public data: any;

  constructor(private filmService: FilmService) {  }

  ngOnInit() {
    this.getFilms();
  }
  ngOnDestroy() {
    
  }
  public getFilms() {
    this.sub = this.filmService.getData().subscribe({
    next: result => {
        console.log(result);
        this.films = result;
       
    },
      error: err => this.errorMessage = err
    });
  }

  
}
