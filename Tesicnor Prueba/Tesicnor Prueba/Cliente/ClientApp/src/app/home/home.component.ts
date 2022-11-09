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

  filteredFilms: IFilm[] = [];


  public data: any;

  private _listFilter: string = '';
  
  get listFilter(): string {
    return this._listFilter;
  }

  set listFilter(value: string) {
    this._listFilter = value;
    console.log('In setter:', value);
    this.filteredFilms = this.performFilter(value);
  }

  performFilter(filterBy: string): IFilm[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.films.filter((film: IFilm) =>
      film.Title.toLocaleLowerCase().includes(filterBy));
  }


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
