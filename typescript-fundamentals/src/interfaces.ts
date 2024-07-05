 export interface Person {
    id: number;
    firstName: string;
    lastName: string;
    sex: "M" | "F";
    birthday: Date;
    pets: number[] | null;
  }
  
  export interface Pet {
    id: number;
    name: string;
    type: "dog" | "cat";
  }