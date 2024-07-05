import { Fragment, useMemo, useState, useEffect } from 'react'
import {
  CalendarIcon,
  ChevronLeftIcon,
  ChevronRightIcon,
  EllipsisHorizontalIcon,
} from '@heroicons/react/20/solid'
import { Menu, Transition } from '@headlessui/react'
import {
  addDays, addMonths,
  endOfMonth, format,
  getDay,
  getDaysInMonth, isSameDay,
  isSameMonth,
  isToday,
  startOfMonth, subMonths,
} from "date-fns";
import { CalendarDay } from './Interfaces/CalendarDay';
import { Employee } from './Interfaces/EmployeeInterface';
import { fetchEmployees } from '../data/APICall';
import { Timesheet } from './Interfaces/TimesheetInterface';
import { useAuth0 } from '@auth0/auth0-react';

function classNames(...classes: string[]) {
  return classes.filter(Boolean).join(' ')
}

function getMonthForCalendar(date: Date): CalendarDay[] {
  const startOfWorkingMonth = startOfMonth(date);
  const endOfWorkingMonth = endOfMonth(date);
  const daysInMonth = getDaysInMonth(date);

  const extraStartDayPadding = getDay(startOfWorkingMonth) % 7;
  const extraEndDayPadding = (7 - getDay(endOfWorkingMonth)) % 7;

  const days: CalendarDay[] = [];

  for (let i = 1 - extraStartDayPadding; i < daysInMonth + extraEndDayPadding; i++) {
    const workingDate = addDays(startOfWorkingMonth, i);

    days.push({
      isToday: isToday(workingDate),
      isWorkingMonth: isSameMonth(date, workingDate),
      date: workingDate,
      formattedDate: workingDate.toDateString(),
    });
  }

  return days;
}

export default function Calendar() {
  const [workingDay, setWorkingDay] = useState<Date>(new Date());
  const workingMonthDays = useMemo(() => getMonthForCalendar(workingDay), [workingDay]);
  const [employees, setEmployees] = useState<Employee[]>([]);
  const [, setSelectedUserId] = useState<string | null>(null);
  const [selectedUserTimesheets, setSelectedUserTimesheets] = useState<Timesheet[]>([]);
  const { isAuthenticated, user } = useAuth0();

  const handleDayClick = (date: Date) => {
    setWorkingDay(date);
  };

  useEffect(() => {
    fetchEmployees(setEmployees)
  }, []);

  useEffect(() => {

    if (isAuthenticated && user?.email) {
      const currentUser = employees.find((employee) => employee.email === user.email);

      if (currentUser) {
        setSelectedUserId(currentUser.id);
        setSelectedUserTimesheets(currentUser.timesheets);
      } else {
        setSelectedUserId(null);
        setSelectedUserTimesheets([]);
      }
    }
  }, [isAuthenticated, user, employees]);

  return (
    <div>

      {isAuthenticated && (
        <div>
          <p>Welcome, {user?.name}</p>
          <p>Email: {user?.email}</p>
        </div>
      )}


      <div className="lg:grid lg:grid-cols-12 lg:gap-x-16">
        <div className="mt-10 text-center lg:col-start-8 lg:col-end-13 lg:row-start-1 lg:mt-9 xl:col-start-9">
          <div className="flex items-center text-gray-900">
            <button
              type="button"
              className="-m-1.5 flex flex-none items-center justify-center p-1.5 text-gray-400 hover:text-gray-500"
              onClick={() => setWorkingDay(subMonths(workingDay, 1))}
            >
              <span className="sr-only">Previous month</span>
              <ChevronLeftIcon className="h-5 w-5" aria-hidden="true" />
            </button>
            <div className="flex-auto text-sm font-semibold">{format(workingDay, 'MMMM yyyy')}</div>
            <button
              type="button"
              className="-m-1.5 flex flex-none items-center justify-center p-1.5 text-gray-400 hover:text-gray-500"
              onClick={() => setWorkingDay(addMonths(workingDay, 1))}
            >
              <span className="sr-only">Next month</span>
              <ChevronRightIcon className="h-5 w-5" aria-hidden="true" />
            </button>
          </div>
          <div className="mt-6 grid grid-cols-7 text-xs leading-6 text-gray-500">
            <div>M</div>
            <div>T</div>
            <div>W</div>
            <div>T</div>
            <div>F</div>
            <div>S</div>
            <div>S</div>
          </div>
          <div className="isolate mt-2 grid grid-cols-7 gap-px rounded-lg bg-gray-200 text-sm shadow ring-1 ring-gray-200">
            {workingMonthDays.map((day, dayIdx) => {
              const isSelected = isSameDay(day.date, workingDay);

              return (
                <button
                  key={day.formattedDate}
                  type="button"
                  onClick={() => handleDayClick(day.date)}
                  className={classNames(
                    'py-1.5 hover:bg-gray-100 focus:z-10',
                    day.isWorkingMonth ? 'bg-white' : 'bg-gray-50',
                    (isSelected || day.isToday) ? 'font-semibold' : '',
                    isSelected ? 'text-white' : '',
                    !isSelected && day.isWorkingMonth && !day.isToday ? 'text-gray-900' : '',
                    !isSelected && !day.isWorkingMonth && !day.isToday ? 'text-gray-400' : '',
                    day.isToday && !isSelected ? 'text-indigo-600' : '',
                    dayIdx === 0 ? 'rounded-tl-lg' : '',
                    dayIdx === 6 ? 'rounded-tr-lg' : '',
                    dayIdx === workingMonthDays.length - 7 ? 'rounded-bl-lg' : '',
                    dayIdx === workingMonthDays.length - 1 ? 'rounded-br-lg' : ''
                  )}
                >
                  <time
                    dateTime={day.formattedDate}
                    className={classNames(
                      'mx-auto flex h-7 w-7 items-center justify-center rounded-full',
                      isSelected && day.isToday ? 'bg-indigo-600' : '',
                      isSelected && !day.isToday ? 'bg-blue-600' : ''
                    )}
                  >
                    {day.date.getDate()}
                  </time>
                </button>
              )
            })}
          </div>
        </div>
        <ol className="mt-4 divide-y divide-gray-100 text-sm leading-6 lg:col-span-7 xl:col-span-8">
          {selectedUserTimesheets.map((timesheet) => {
            const selectedDayTimesheet = timesheet.registrations.find((registration) =>
              isSameDay(new Date(registration.timeSlot.start), workingDay)
            );

            if (selectedDayTimesheet) {
              return (
                <li key={timesheet.id} className="relative flex space-x-6 py-6 xl:static">
                  <div className="flex-auto">
                    <h3 className="pr-10 font-semibold text-gray-900 xl:pr-0">Timesheet Details</h3>
                    <dl className="mt-2 flex flex-col text-gray-500 xl:flex-row">
                      <div className="flex items-start space-x-3">
                        <dt className="mt-0.5">
                          <span className="sr-only">Date</span>
                          <CalendarIcon className="h-5 w-5 text-gray-400" aria-hidden="true" />
                        </dt>
                        <dd>
                          <time dateTime={timesheet.id.toString()}>Timesheet ID: {timesheet.id}</time>
                        </dd>
                      </div>
                    </dl>
                    <dl className="mt-2 flex flex-col text-gray-500 xl:flex-row">
                      <div className="flex items-start space-x-3">
                        <dt className="mt-0.5">
                          <span className="sr-only">Year</span>
                        </dt>
                        <dd>Year: {timesheet.year}</dd>
                      </div>
                    </dl>
                    <dl className="mt-2 flex flex-col text-gray-500 xl:flex-row">
                      <div className="flex items-start space-x-3">
                        <dt className="mt-0.5">
                          <span className="sr-only">Month</span>
                        </dt>
                        <dd>Month: {timesheet.month}</dd>
                      </div>
                    </dl>
                    <dl className="mt-2 flex flex-col text-gray-500 xl:flex-row">
                      <div className="flex items-start space-x-3">
                        <dt className="mt-0.5">
                          <span className="sr-only">Registrations</span>
                        </dt>
                        <dd>
                          Registrations:
                          <ul>
                            <li key={selectedDayTimesheet.id}>
                              Type: {selectedDayTimesheet.registrationType}
                              <br />
                              Time Slot: {`${selectedDayTimesheet.timeSlot.start} - ${selectedDayTimesheet.timeSlot.end}`}
                            </li>
                          </ul>
                        </dd>
                      </div>
                    </dl>
                  </div>
                  <Menu as="div" className="absolute right-0 top-6 xl:relative xl:right-auto xl:top-auto xl:self-center">
                    <div>
                      <Menu.Button className="-m-2 flex items-center rounded-full p-2 text-gray-500 hover:text-gray-600">
                        <span className="sr-only">Open options</span>
                        <EllipsisHorizontalIcon className="h-5 w-5" aria-hidden="true" />
                      </Menu.Button>
                    </div>

                    <Transition
                      as={Fragment}
                      enter="transition ease-out duration-100"
                      enterFrom="transform opacity-0 scale-95"
                      enterTo="transform opacity-100 scale-100"
                      leave="transition ease-in duration-75"
                      leaveFrom="transform opacity-100 scale-100"
                      leaveTo="transform opacity-0 scale-95"
                    >
                      <Menu.Items className="absolute right-0 z-10 mt-2 w-36 origin-top-right rounded-md bg-white shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none">
                        <div className="py-1">
                          <Menu.Item>
                            {({ active }) => (
                              <a
                                href="#"
                                className={classNames(
                                  active ? 'bg-gray-100 text-gray-900' : 'text-gray-700',
                                  'block px-4 py-2 text-sm'
                                )}
                              >
                                Edit
                              </a>
                            )}
                          </Menu.Item>
                          <Menu.Item>
                            {({ active }) => (
                              <a
                                href="#"
                                className={classNames(
                                  active ? 'bg-gray-100 text-gray-900' : 'text-gray-700',
                                  'block px-4 py-2 text-sm'
                                )}
                              >
                                Cancel
                              </a>
                            )}
                          </Menu.Item>
                        </div>
                      </Menu.Items>
                    </Transition>
                  </Menu>
                </li>
              );
            } else {
              return null;
            }
          })}
        </ol>
      </div>
    </div>
  )
}