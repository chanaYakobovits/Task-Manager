import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-task',
  imports: [],
  templateUrl: './task.html',
  styleUrl: './task.css'
})
export class Task {

    // constructor(private router: Router) { }
    // // applicationService: ApplicationDetailsService = inject(ApplicationDetailsService);
  
    // // list$!: Observable<AllRequestsModel[]>;
    // // allRequests: AllRequestsModel[] = [];
    // // filteredList: AllRequestsModel[] = [];
    // searchQuery: string = '';
    // selectedTab: string = 'open';
    // openRequestsCount: number = 0;
    // closedRequestsCount: number = 0;
    // sortDirection: 'asc' | 'desc' = 'asc';
    // selectedRequest: any = null;
    // selectedRowIndex = 0;
    // ngOnInit(): void {
    //   this.list$ = this.applicationService.GetAllRequest().pipe(
    //     tap(requests => {
    //       this.allRequests = requests;
  
    //       this.openRequestsCount = this.allRequests.filter(r => !r.completed).length;
    //       this.closedRequestsCount = this.allRequests.filter(r => r.completed).length;
  
    //       this.filterRequests();
    //     }),
    //     catchError(error => {
    //       console.error('Error fetching requests:', error);
    //       return of([]);
    //     })
    //   );
  
  
  
    //   this.list$.subscribe();
    // }
  
    // filterRequests(): void {
    //   const query = this.searchQuery.trim().toLowerCase();
  
    //   // סינון לפי טאב
    //   let filtered = this.allRequests.filter(request =>
    //     this.selectedTab === 'open' ? !request.completed : request.completed
    //   );
  
    //   // סינון לפי חיפוש
    //   if (query) {
    //     filtered = filtered.filter(request =>
    //       (request.applicantName || '').toLowerCase().includes(query) ||
    //       (request.nameUnit || '').toLowerCase().includes(query) ||
    //       (request.facility || '').toLowerCase().includes(query)
    //     );
    //   }
  
    //   this.filteredList = filtered;
    // }
  
    // selectTab(tab: string) {
    //   this.selectedTab = tab;
    //   this.filterRequests(); // כדי לעדכן את התצוגה בהתאם לטאב שנבחר
    // }
  
  
    // sortByDate() {
    //   this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    //   this.filteredList.sort((a, b) => {
    //     const dateA = new Date(a.requestDate).getTime();
    //     const dateB = new Date(b.requestDate).getTime();
    //     return this.sortDirection === 'asc' ? dateA - dateB : dateB - dateA;
    //   });
    // }
  
    // selectRequest(request: any) {
    //   this.selectedRequest = request;
    // }
  
 
}
