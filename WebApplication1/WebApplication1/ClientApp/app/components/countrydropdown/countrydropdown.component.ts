import { Component } from '@angular/core';

@Component({
    selector: 'countrydropdown',
    templateUrl: './countrydropdown.component.html'
})
export class CountryDropDownComponent {
    countryList: Country[] = [{ CountryId: 1, CountryName="America"}];
}

interface Country {
    CountryId: number;
    CountryName: string
}