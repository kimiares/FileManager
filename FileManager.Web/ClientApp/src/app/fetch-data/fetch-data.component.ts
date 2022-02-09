import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FileSystemModel } from './IFileSystemModel';




@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  styles: ['./fetch-data.component.css']
})

export class FetchDataComponent implements OnInit
{
  
  public firstPanelFiles: FileSystemModel[];
  public checkedFiles?: string[] = [];

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
  
  onCheck(event) {

    
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
    //this.selectedFile = file;
    
    this.http.post<FileSystemModel[]>(this.baseUrl + 'panel/open', file).subscribe(result => {
      this.firstPanelFiles = result;
    },
      error => console.error(error));


  }

  refresh(): void {
    window.location.reload();
  }

  onDeleteTest(): void {
    //this.http.post<string[]>(this.baseUrl + 'panel/delete', this.checkedFiles).subscribe((ok) => { console.log(ok) });

    this.http.post<FileSystemModel[]>(this.baseUrl + 'panel/delete', this.checkedFiles).subscribe(result => {
      this.firstPanelFiles = result;
    });

    //this.refresh();

  }


 

  

}



