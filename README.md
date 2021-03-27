# Week 9
# Consolidation

## Rest API
* [Site for the Rest API URL](https://csl-restapiweek-9.azurewebsites.net)
* [Link for the Information System Repo](https://github.com/Surveytech/Rocket-Elevator-Foundation_RestAPI.git)
* [Endpoint to GET the Interventions with "Pending" status](https://csl-restapiweek-9.azurewebsites.net/interventions/getpendinginterventions)
* [Endpoint to change (PUT) the Intervention #5 status to "InProgress" and add START date and time](https://csl-restapiweek-9.azurewebsites.net/interventions/5/updatestatusdatestart)
* [Endpoint to change (PUT) the Intervention #5 status to "Completed" and add END date and time](https://csl-restapiweek-9.azurewebsites.net/interventions/5/updatestatusdateend)


For the Rest Api, I have done a scaffold to produce my **InterventionsController.cs** and the **Intervention.cs** model.

I have done 3 endpoints in the **InterventionsController.cs** for the requests:
* First one is the **getpendinginterventions** ; to retrieve all Interventions with a status to Pending
* Second one is the **{id}/updatestatusdatestart** ; to change the status of an Intervention {by is id} to InProgress and add a start date and time
* Third one is the **{id}/updatestatusdateend** ; to change the status of an Intervention {by is id} to Completed and add a end date and time

In this repo you will find the **Postman collection** for :
* the Intervention requests :
 CSL Week #9.postman_collection.json
* Week 7/8 Request :  team4week8.postman_collection.json



