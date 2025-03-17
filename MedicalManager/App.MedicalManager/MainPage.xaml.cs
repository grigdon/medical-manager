﻿namespace App.MedicalManager
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void PatientsClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Patients");
        }

        private void PhysiciansClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Physicians");
        }

        private void AppointmentsClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Appointments");
        }
        private void TreatmentsClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Treatments");
        }

        private void PoliciesClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//InsurancePolicies");
        }
    }
}
