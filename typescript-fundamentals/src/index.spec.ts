
// Stap 1: maak een interface aan voor `Person` en `Pet`, en zorg ervoor dat de `persons` en `pets` arrays typed zijn
import { Person, Pet } from "./interfaces";
import { persons, pets} from './data'
import { calculateAge, updatePerson, DatetimeService,MockDatetimeService, testClass, GitHubProfileService } from "./functions";

// Stap 2: implementeer de volgende testen door gerbuik te maken van JS Array methodes op een pure manier

// Test 1

it("wat is de naam van persoon met id 3", () => { const personWithId3: Person | undefined = persons.find(person => person.id === 3);

  if (personWithId3) 
  {
    const { firstName, lastName } = personWithId3;
    const fullName: string = `${firstName} ${lastName}`;
    
    expect(fullName).toBe("Bob Peeters");
  } 
  else 
  {
    throw new Error("Person with id 3 not found");
  }
});

// Test 2

it("hoeveel mannelijke personen zijn er", () => {
  const malePersonsCount = persons.filter(person => person.sex === "M").length;
  
  expect(malePersonsCount).toBe(2); 
});

// Test 3

it("wat zijn de volledige namen van de personen", () => {
  const fullNames = persons.map(person => `${person.firstName} ${person.lastName}`);
  const expectedFullNames = ["John Peeters", "Alice Peeters", "Bob Peeters"];

  expect(fullNames).toEqual(expectedFullNames);
});

// Test 4

it("zoek alle personen met een cat als pet", () => { 
  const catOwnersCount = persons.reduce((count, person) => {
    if (person.pets) {
      const personPets: Pet[] = person.pets.map(petId => pets.find(pet => pet.id === petId)).filter(Boolean) as Pet[];
      if (personPets.some(pet => pet.type === "cat")) {
        return count + 1;
      }
    }
    return count;
  }, 0);

  expect(catOwnersCount).toBe(2); 
});

// Test 5

it("transformeer de personen array naar een nieuwe array met properties {id, fullName, age} en sorteer by leeftijd", () => {
  const transformedPersons = persons.map(person => {
    const { id, firstName, lastName, birthday } = person;
    const fullName = `${firstName} ${lastName}`;
    const age = calculateAge(birthday);
    
    return { id, fullName, age };
  });

  console.log(transformedPersons);

  const sortedByAge = transformedPersons.sort((personA, personB) => personB.age - personA.age);

  const expectedSortedByAge = [
    { id: 1, fullName: "John Peeters", age: calculateAge(new Date(1991, 5, 27)) },
    { id: 2, fullName: "Alice Peeters", age: calculateAge(new Date(1995, 10, 8)) },
    { id: 3, fullName: "Bob Peeters", age: calculateAge(new Date(2000, 9, 10)) }
  ];

  expect(sortedByAge).toEqual(expectedSortedByAge);
});

// Test 6

it("maak een nieuwe array waarbij de persoon de details bevat van de pets", () => {
  const personsWithPetDetails = persons.map(person => {
    const personPets = person.pets
      ? person.pets.map(petId => pets.find(pet => pet.id === petId)).filter(Boolean)
      : [];

    const personWithPets = { ...person, pets: personPets };
    return personWithPets;
  });

  const expectedPersonsWithPetDetails = [
    {
      id: 1,
      firstName: "John",
      lastName: "Peeters",
      birthday: new Date(1991, 5, 27),
      sex: "M",
      pets: [
        { id: 10, name: "Bobby", type: "dog" },
        { id: 20, name: "Mimi", type: "cat" }
      ]
    },
    {
      id: 2,
      firstName: "Alice",
      lastName: "Peeters",
      birthday: new Date(1995, 10, 8),
      sex: "F",
      pets: []
    },
    {
      id: 3,
      firstName: "Bob",
      lastName: "Peeters",
      birthday: new Date(2000, 9, 10),
      sex: "M",
      pets: [{ id: 30, name: "Aiko", type: "cat" }]
    }
  ];

  expect(personsWithPetDetails).toEqual(expectedPersonsWithPetDetails);
});


// Stap 3: functions testen

// Test 7 

it("update a person's details using the updatePerson function", () => {
  const updatedPersonDetails: Person = {
    id: 1,
    firstName: "Bert",
    lastName: "Van Itterbeeck",
    birthday: new Date(1980, 4, 19),
    sex: "M", 
    pets: [10, 20],
  };

  const updatedPersons = updatePerson(persons, updatedPersonDetails, person => person.id === 1);

  const updatedPersonIndex = updatedPersons.findIndex(person => person.id === 1);

  expect(updatedPersonIndex).not.toBe(-1);
  expect(updatedPersons[updatedPersonIndex]).toMatchObject(updatedPersonDetails);
  expect(persons).not.toEqual(updatedPersons);
});



// Stap 4: testen met gebruik te maken van Mocks

// test 8

it("zorg ervoor dat getCurrentTime altijd dezelfde waarde returned (via een mock)", () => {
  const mockDatetimeService = new MockDatetimeService();
  const datetimeService = new DatetimeService();
  const timeMock = jest.fn();
  const mockData = 324943200;
  const bound = timeMock.bind(mockData);
  bound();
  
  const mockInstance = new testClass(mockDatetimeService);
  const instance = new testClass(datetimeService);

  const mocktime1 = mockInstance.returnTime();
  const mocktime2 = mockInstance.returnTime();
  const realTime = instance.returnTime();

  const originalDateNow = Date.now;
  Date.now = jest.fn(() => mockData);
  let test = Date.now();
  console.log(test);
  const timeStamp = instance.returnTime();
  Date.now = originalDateNow;
  test = Date.now(); 
  console.log(test)

  jest.spyOn(Date,'now').mockReturnValue(324943200);
  const spyOnResult = datetimeService.getCurrentTime();
  jest.spyOn(Date, 'now').mockRestore();

  expect(mocktime1).toBe(mocktime2);
  expect(mocktime1).toBe(timeMock.mock.instances[0]);
  expect(timeStamp).toBe(mockData);
  expect(spyOnResult).toBe(mockData);
  expect(mocktime1).not.toBe(realTime);
});

// test 9

it("mock de getUser methode van GitHubProfileService zodat het een gemockte user returned", async () => {
  const gitTest = new GitHubProfileService();
  let mockUser = jest.fn()
  let name: string = "Bert Van Itterbeeck";
  const bound = mockUser.bind(name)
  bound()
  let returnValue: string = "";

  const GitHubProfileServiceReturnValue = gitTest.getUser(mockUser.mock.instances[0]);
  console.log(GitHubProfileServiceReturnValue)
  
  const result = await GitHubProfileServiceReturnValue;
  returnValue = result.username;
  console.log(returnValue);

  expect(name).toBe(returnValue);
});
