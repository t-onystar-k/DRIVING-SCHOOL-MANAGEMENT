
# HealthCare Tracking System
###### 2nd February 2021
## OVERVIEW
HealthCare Tracking System is an app that allows individuals to check their healthcare details and the hospitals to update the visit/health details of patients. The data is stored in a centralised server which connects all the hospitals in the country.
# Intended Users
## 1.Individuals
* Individuals can login to the application using their Aadhar uid and password.
## 2.Hospitals
* Hospitals can login with the unique Id,password they are provided with.
# Specifications
The landing page will have 2 options for login. One for individuals and another for Hospitals
## 1.Individual login:
* Individuals can login using their Aadhar uid as username.
* After login users are taken to a dashboard where they can view their profile information and are also presented with some options, some of which includes the following:
  * Their hospital visiting history
  * Etc
* They also have the option to view and edit their profile. The information they can edit in profile are:
  * Phone no.
  * Email
## 2.Hospital login:
* Hospitals can login to the application using the unique Id they are provided.
* After login hospitals are taken to a dashboard where they can view patient details by typing in their Aadhar id.
* They can also input patient hospital visit details such as:
  * Reason for visit
  * Doctor's obsvn
  * Prescription
# Databases Required 
###### 1. IndividualUsers
  * Details about all individual users like uid, name, phone no etc
###### 2. UserLogin
  * Username,password pairs for authentication
###### 3. Hospitals
  * Details of all hospitals in the system like hospital Id, hosp. Name, address etc
###### 4. HospitalLogin
  * Hospital Id , password pair for authentication
###### 5. Doctors
  * doctorId, Name, Hospital
###### 6. PatientVisitHistory
  * Table to hold the visiting details of individuals
  * Expected columns:
    * UserId
    * Hospital-Id
    * Date of visit
    * Reason of visit
    * Doctor's observation
    * Prescription

