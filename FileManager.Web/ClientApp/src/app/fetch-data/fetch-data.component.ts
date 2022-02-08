import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  styles: [`
.quizzes li, .quizzes tr {
    color: black;
    cursor: pointer;
  }
.quizzes tr {
    color: black;
    cursor: pointer;
  }

.quizzes li:hover, .quizzes tr:hover {
    color: green;
    cursor: pointer;
  }

.quizzes tr:hover {
    color: green;
    cursor: pointer;
  }

.quizzes tr.selected, .quizzes li.selected {
    cursor: pointer;
  color: red;
}`]
})
//export class FetchDataComponent {
//  public forecasts: TestClass[];

//  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
//    http.get<TestClass[]>(baseUrl + 'weatherforecast').subscribe(result => {
//      this.forecasts = result;
//    }, error => console.error(error));
//  }
//}
export class FetchDataComponent implements OnInit
{
  
  public firstPanelFiles: FileSystemModel[];
  public checkedFiles?: number[] = [];

  public selectedFile?: FileSystemModel;
  public title: string;
  public http: HttpClient;
  public baseUrl: string;
  

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    this.title = "Files Windows";
    this.http = http;
    this.baseUrl = baseUrl;
    http.get<FileSystemModel[]>(baseUrl + 'panel')
      .subscribe(result =>
      {
        this.firstPanelFiles = result;
        
      },
        error => console.error(error));
  }
  ngOnInit(): void {
  }
  //onClickMe(event?: MouseEvent, file: FileSystemModel ) {
    
  //  alert('Click!');

    
  //}
  onCheck(event) {

    //if (event.target.value !== undefined) {
    //  this.checkedFiles.push(event.target.value);
    //}
    //this.checkedFiles += event.target.value;
    this.checkedFiles.push(event.target.value);
    
    console.log(event.target.value);    
  }

  printChecked() {

    console.log(this.checkedFiles);
    this.checkedFiles.forEach(function (file) {
      console.log(file)}
    );

  }


  onSelect(file: FileSystemModel):void {
    this.selectedFile = file;
    
    this.http.post<FileSystemModel[]>(this.baseUrl + 'panel/open', file).subscribe(result => {
      this.firstPanelFiles = result;
    },
      error => console.error(error));


  }


  onDelete(): void  {

    var reqHeader = new HttpHeaders({
      "Content-Type": "application/json",
    });
    const httpOptions = {
      headers: reqHeader,
      body: this.checkedFiles
    };

    this.http.delete(this.baseUrl + 'panel / delete', httpOptions)
      .subscribe((ok) => { console.log(ok) });


  }

  

}

//interface WeatherForecast {
//  date: string;
//  temperatureC: number;
//  temperatureF: number;
//  summary: string;
//}

//interface TestClass {
//  Name: string;
//  Number: number;
  
//}


interface FileSystemModel {
  id: number;
  fullName: string;
  name: string;
  creationTime: Date; 
  
}
