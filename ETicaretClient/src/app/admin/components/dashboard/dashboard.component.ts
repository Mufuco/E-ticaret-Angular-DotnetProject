import { Component, OnInit } from '@angular/core';
import { AlertiyfService, MessageType, Position } from 'src/app/services/admin/alertiyf.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  constructor(private alertify:AlertiyfService) { }

  ngOnInit(): void {
    
  }
  
  }
  





