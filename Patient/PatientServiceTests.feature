Feature: PatientServiceTests
As a Patient
I want to register on the platform
Given I want to be able to search for psychologists and schedule appointments

    @patient-adding
    Scenario: Add Patient
        Given The Endpoint https://localhost:5001/api/v1/patients is available
        When A Patient Request is sent
          | FirstName | LastName | Email                | Password | Phone     | Date       | Gender | State  | Img     |
          | Debie     | Garcia   | debiebts@hotmail.com | bts12345 | 987654321 | 2001-11-19 | Female | Single | example |
        Then A Response with Status 200 is received for the patient