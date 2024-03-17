import { Component, Input } from '@angular/core';
import { TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { Sprint } from '../types/sprint';
import { Ticket, TicketTableData } from '../types/ticket';
import { tick } from '@angular/core/testing';

@Component({
  selector: 'app-sprint-tickets',
  standalone: true,
  imports: [TableModule, TagModule],
  templateUrl: './sprint-tickets.component.html',
  styleUrl: './sprint-tickets.component.css',
})
export class SprintTicketsComponent {
  @Input() currentSprint!: Sprint | null;

  // Replace with proper data call when im done building the table
  ticketList: TicketTableData[] | null = [
    {
      id: '10037',
      self: 'https://hf-sandbox.atlassian.net/rest/api/2/issue/10037',
      fields: {
        priority: {
          name: 'Medium',
        },
        status: {
          name: 'Done',
        },
        customfield_10020: [
          {
            id: 6,
            name: 'SCRUM Sprint 6',
            startDate: '2023-03-11T14:00:00Z',
            endDate: '2023-03-25T14:00:00Z',
          },
        ],
        customfield_10016: 2,
        summary: 'test',
      },
    },
    {
      id: '10020',
      self: 'https://hf-sandbox.atlassian.net/rest/api/2/issue/10020',
      fields: {
        priority: {
          name: 'Medium',
        },
        status: {
          name: 'Done',
        },
        customfield_10020: [
          {
            id: 6,
            name: 'SCRUM Sprint 6',
            startDate: '2023-03-11T14:00:00Z',
            endDate: '2023-03-25T14:00:00Z',
          },
        ],
        customfield_10016: 2,
        summary: 'test',
      },
    },
    {
      id: '10019',
      self: 'https://hf-sandbox.atlassian.net/rest/api/2/issue/10019',
      fields: {
        priority: {
          name: 'Medium',
        },
        status: {
          name: 'Done',
        },
        customfield_10020: [
          {
            id: 6,
            name: 'SCRUM Sprint 6',
            startDate: '2023-03-11T14:00:00Z',
            endDate: '2023-03-25T14:00:00Z',
          },
        ],
        customfield_10016: 1,
        summary: 'test',
      },
    },
  ].map((ticket) => {
    return {
      id: ticket.id,
      self: ticket.self,
      summary: ticket.fields.summary,
      priority: ticket.fields.priority.name,
      status: ticket.fields.status.name,
      sprintName: ticket.fields.customfield_10020[0].name,
      points: ticket.fields.customfield_10016,
    };
  });

  ngOnChange(): void {}
}
