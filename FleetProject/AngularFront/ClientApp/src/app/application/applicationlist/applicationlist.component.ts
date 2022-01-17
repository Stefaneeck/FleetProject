import { Component, OnInit } from '@angular/core';
import { ApplicationService } from '../application.service';
import { IApplication } from '../../domain/IApplication';

@Component({
  selector: 'app-applicationlist',
  templateUrl: './applicationlist.component.html',
  styleUrls: ['./applicationlist.component.css']
})
export class ApplicationlistComponent implements OnInit {

  public applications: IApplication[];
  errorMessage = '';

  constructor(private applicationService: ApplicationService) { }

  ngOnInit() {

    this.applicationService.getApplications().subscribe({
      next: applications => {
        this.applications = applications;

      },
      error: err => this.errorMessage = err
    });
  }

  getApplicationStatusViewValue(enumValue: number): string {

    return this.applicationService.showEnumValueApplicationStatus(enumValue);
  }

  getApplicationTypeViewValue(enumValue: number): string {

    return this.applicationService.showEnumValueApplicationType(enumValue);
  }

}
