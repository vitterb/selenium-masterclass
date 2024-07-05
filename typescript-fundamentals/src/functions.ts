// functions.ts
import { Person } from './interfaces';

export function updatePerson(existingPersons: Person[], updatedPerson: Partial<Person>, predicate: (person: Person) => boolean): Person[] {
  return existingPersons.map(person => {
    if (predicate(person)) {
      return { ...person, ...updatedPerson };
    }
    return person;
  });
}


 export function calculateAge(birthDate: Date): number {
    const today = new Date();
    const birthYear = birthDate.getFullYear();
    const birthMonth = birthDate.getMonth();
    const birthDay = birthDate.getDate();
  
    const age = today.getFullYear() - birthYear - (today.getMonth() < birthMonth || (today.getMonth() === birthMonth && today.getDate() < birthDay) ? 1 : 0);
    
    return age;
  }

  export class DatetimeService {
    getCurrentTime() {
      return Date.now();
    }
  }
  
  export class MockDatetimeService {
    getCurrentTime() {
      return 324943200;
    }
  } 
  
  export class testClass {
    private datetimeService: DatetimeService;
  
    constructor(datetimeService: DatetimeService){
      this.datetimeService = datetimeService;
    }
  
    returnTime(){
      const currentTime = this.datetimeService.getCurrentTime();
      return currentTime;
    }
  }
  export class GitHubProfileService {
     getUser(username: string): Promise<{ username: string }> {
        return Promise.resolve({username})
    }
  }

 
 