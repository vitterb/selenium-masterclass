export interface Registration {
    id: number;
    registrationType: string;
    timeSlot: {
        start: string;
        end: string;
    };
}
