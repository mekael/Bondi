import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-issue-index',
  templateUrl: './issue-index.component.html'
})
export class IsssueIndexComponent {
  public thumbnails: IssueThumbnail[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    let issueThumbnailQuery: IssueThumbnailQuery;
    issueThumbnailQuery.IssueYear = 1925;
    issueThumbnailQuery.MagazineId = 1;
     

    http.get<IssueThumbnail[]>(baseUrl + '/api/thumbnail/CoverThumbnails').subscribe(result => {
      this.thumbnails = result;
    }, error => console.error(error)); 
  }
}


interface IssueThumbnail {
  IssueId: number;
  PublishedOnDate: string;
  Thumbnail: Blob;
}

interface IssueThumbnailQuery {

  MagazineId: number;
  IssueYear: number;
}
