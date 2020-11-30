# netCoreTest

## Starting the project

`git clone https://github.com/fleonardelli/netCoreTest.git`

`cd netCoreTest`

`docker-compose up --build`

The project will be running in https://localhost:8001

If you want to check the database, all the configuration is in `docker-compose.yaml` or `appsettings.Docker.json`

## Data seeding

The project will have already fake data in the database. 

### Users
emails: parent@google.com, kid@google.com - you can test both roles here. 

### Device
Only one device, Id 1. 

### Users Device Permission
User parent@google.com has Permissions 1 and 2 (Lock, Unlock) for the Device 1

User kid@google.com has Permissions 3 and 4 (Request_lock, Request_unlock) for the Device 1

## Endpoints

### Auth
Endpoint: `GET /api/user/login`

Expected Body: `{"email" : "theEmail", "externalToken": "SSOToken(No need to be a real token)"}`

Result: `Dto with JWT token. You need the token to use the next endpoints.` 

### Device
Endpoint: `GET /device`

Expected Body: `{}`

Authorization: `Bearer Token - JWT token got from the login endpoint.`

Result: `List of all devices`

### Perform an action on a device - i.e Lock door
Endpoint: `POST /device/action`

Expected Body: `{"deviceId": 1, "actionId": 1}` - There is onle device, but 4 actions check different messages.

Authorization: `Bearer Token - JWT token got from the login endpoint.`

Result: `Response with a message`


## Improvements

The most needed improvements are:
- Unit test
- Endpoint to fetch the Actions
- Permissions table might be renamed to Action, you will see in the code I used action in some places
- There are some comments about the endpoints and usage of Dtos, and in the Services
- Separate development Fake data and actual startup data in different Classes, and load them depending on the environment
- Endpoints returning data they expect - This is super important, either we need this or some platform like Apiary
