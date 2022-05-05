Feature: PsychologistServiceTests
As a Psychologist
I want to register on the platform
Given I want extra income through appointments that can schedule me 
And publish recommendations for my patients

    @psychologist-adding
    Scenario: Add Psychologist
        Given The Endpoint https://localhost:5001/api/v1/psychologists is available
        When A Psychologist Request is sent
          | Name   | Age        | Dni     | Email          | Password  | Phone     | Specialization      | Formation                                 | About                               | Active | New  | Img     | Cmp    | Genre  | SessionType |
          | Nataly | 21/11/1990 | 7894561 | naty@gmail.com | admin1234 | 963258741 | Autoestima y Estres | Universidad Peruana de Ciencias Aplicadas | Soy una persona feliz de mi trabajo | true   | true | example | 112345 | Female | Individual  |
        Then A Response with Status 200 is received for the psychologist