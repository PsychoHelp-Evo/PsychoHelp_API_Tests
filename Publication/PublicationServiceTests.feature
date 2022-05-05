Feature: PublicationServiceTests
As a Psychologist
I want to publish recommendations for my patients
Given my patients can read and follow the advice

    @publication-adding
    Scenario: Add Publication
        Given The Endpoint https://localhost:5001/api/v1/publications is available
        When A Publication Request is sent
          | Title                | Description                         | PsychologistId |
          | Perdidad de familiar | Una perdida puede ser muy dolorosa  | 2              |
        Then A Response with Status 200 is received for the publication