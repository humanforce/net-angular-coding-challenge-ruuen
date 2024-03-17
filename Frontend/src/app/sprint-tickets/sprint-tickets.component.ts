import { Component, Input, inject } from '@angular/core';
import { TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { Sprint } from '../types/sprint';
import { Ticket, TicketTableData } from '../types/ticket';
import { TicketService } from '../ticket.service';

@Component({
  selector: 'app-sprint-tickets',
  standalone: true,
  imports: [TableModule, TagModule],
  templateUrl: './sprint-tickets.component.html',
  styleUrl: './sprint-tickets.component.css',
})
export class SprintTicketsComponent {
  ticketService: TicketService = inject(TicketService);
  @Input() selectedSprint!: Sprint | null;

  ticketList: TicketTableData[] | null = null;

  ngOnChanges(): void {
    if (this.selectedSprint == null) {
      return;
    }

    this.ticketService
      .getTicketsBySprint(this.selectedSprint.id)
      .subscribe((rawTicketList) => {
        const mappedTickets = rawTicketList.map((ticket) => {
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

        this.ticketList = mappedTickets;
      });
  }
}
