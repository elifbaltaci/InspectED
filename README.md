# Chromebook Readiness and Tracking System

## Project Overview
This project is a web-based Chromebook Readiness and Tracking System designed to help school IT staff manage devices more efficiently during testing season.

This project aims to create a more organized and user-friendly system for managing Chromebook information, inspection results, and testing readiness.

## Problem Statement
The current process of tracking Chromebooks in spreadsheets makes it difficult to:
- keep device information organized
- track physical device condition clearly
- identify which Chromebooks are ready for testing
- update records efficiently
- manage the process in a more structured way

## Proposed Solution
The proposed solution is a web application that allows IT staff to:
- store Chromebook inventory information
- track assigned users
- record inspection details
- mark devices as ready or not ready for testing
- manage device condition data in one centralized system

## Target Users
- School IT staff
- Technology coordinators
- School administrators who may need quick device readiness reports

## Features
### Current Progress
- Installed Entity Framework Core
- Created models/entities
- Created DbContext class
- Registered DbContext with ASP.NET Core dependency injection
- Added migration and updated database
- Set up repository pattern
- Added side navigation bar
- Added basic UI using Bootstrap and Bootstrap Icons

### Planned Features
- Device inventory management
- Device input form
- Form submission handling
- ViewModels
- Strongly typed views
- Inspection tracking
- Testing readiness status
- Dashboard for device overview

## Technologies Used
- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- Bootstrap

## Database Design
The system is planned around the following main components:
- Devices
- Assignments
- Inspections

## Workflow
1. IT staff logs into the system
2. User searches or selects a Chromebook
3. User views or updates device details
4. User fills out inspection form and submits it
5. System updates testing readiness status
6. Dashboard/report reflects current device condition

## Project Status
This project is currently in progress. The backend foundation has been completed, and the UI and form functionality are now being developed.

## Future Improvements
- Search and filter options
- Repair tracking
- Reporting features
- Better dashboard analytics
- Role-based access if needed

## Author
Elif Sare Baltaci
