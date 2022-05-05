Feature: AppointmentServiceTests
AppointmentServiceTests
As a Patient
I want to add new Appointment through plataform
Given I want to have my appointment scheduled

    @appointment-adding
    Scenario: Add Appointment
        Given The Endpoint https://localhost:5001/api/v1/appointment is available
        When A Appointment Request is sent
          | PsychoNotes | ScheduleDate | CreatedAt  | Motive     | PersonalHistory          | TestRealized  | Treatment                   | PatientId | PsychoId |
          | Example     | 2021-11-19   | 2021-11-19 | Autoestima | Persona con mucho estres | Test de dolor | Tratamiento de recuperacion | 2         | 1        |
        Then A Response with Status 200 is received for the appointment