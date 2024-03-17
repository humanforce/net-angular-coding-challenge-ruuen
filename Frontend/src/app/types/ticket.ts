export interface Ticket {
  id: string;
  self: string;
  fields: {
    priority: {
      name: string;
    };
    status: {
      name: string;
    };
    customfield_10020: [
      { id: number; name: string; startDate: string; endDate: string }
    ];
    customfield_10016: number;
    summary: string;
  };
}

export interface TicketTableData {
  id: string;
  self: string;
  summary: string;
  priority: string;
  status: string;
  sprintName: string;
  points: number;
}
