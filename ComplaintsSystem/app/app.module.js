(function () {
    'use strict';

    angular.module('app', ['ngRoute'])
    .config(['$routeProvider', '$locationProvider',
  function ($routeProvider, $locationProvider) {
      console.log($routeProvider);
      console.log("Configuration hook");
      $routeProvider.
        when('/showComplaints', {
            templateUrl: 'app/Views/showComplaints.html'
        }).
        when("/addComplaint", {
            templateUrl: 'app/Views/addComplaint.html'
        }).otherwise({
            redirectTo: '/',
        });
      $locationProvider.html5Mode({ enabled: true, requireBase: false });
  }
])
    .service("TicketService", function ($http) {

        this.getStatus = function () {
            return $http.get('/api/TicketStatus')
        }
        this.getStudents = function () {
            return $http.get('/api/Students')
        }
        this.getTypes = function () {
            return $http.get('/api/ComplaintTypes')
        }
        //Read all Courses
        this.getCourses = function () {

            return $http.get('/api/Courses');
        };

        //Read all Branches by Course
        this.getBranchByCourses = function (id) {

            return $http.get('/api/Branches/GetBranchByCourse/' + id);
        };

        //Read all Students by branches
        this.getStudentsByBranchId = function (id) {

            return $http.get('/api/Students/GetStudentsByBranch/' + id);
        };

        //Read all Employees
        this.getTickets = function () {

            return $http.get('/api/Tickets');
        };

        //Fundction to Read Employee ID
        this.getTicket = function (id) {
            return $http.get("/api/Tickets/" + id);
        };

        //Function to create new Employee
        this.post = function (Tickets) {
            var request = $http({
                method: "post",
                url: "/api/Tickets",
                data: Tickets
            });
            return request;
        };

        //Edit Employees By ID 
        this.put = function (id, Ticket) {
            var request = $http({
                method: "put",
                url: "/api/Tickets/" + id,
                data: Ticket
            });
            return request;
        };

        //Delete Employees ID
        this.delete = function (id) {
            var request = $http({
                method: "delete",
                url: "/api/Tickets/" + id
            });
            return request;
        };

    })

    .controller('ticketsController',['$scope','TicketService', function ($scope, TicketService) {
        //$scope.getData = function () {
        var editMode = true;
        var getStatus = TicketService.getStatus();
        getStatus.then(function (response) {
            $scope.Statuses = response.data;
        }, function (error) {
        });

        var getStudents = TicketService.getStudents();
        getStudents.then(function (response) {
            $scope.StudentsList = response.data;
        }, function (error) {
        });

        var getTypes = TicketService.getTypes();
        getTypes.then(function (response) {
            $scope.Types = response.data;
        }, function (error) {
        });
        console.log('controller');
        var getCourses = TicketService.getCourses();
        getCourses.then(function (response) {
            $scope.Courses = response.data;
        }, function (error) {
        });

        var getPromise = TicketService.getTickets();
        getPromise.then(function (response) {
            $scope.Tickets = response.data;
        }, function (error) {
        });
        $scope.getBranch = function () {
            var promiseBranch = TicketService.getBranchByCourses(this.CourseId.CourseId);
            promiseBranch.then(function (response) {
                $scope.Branches = response.data;
            }, function (error) {
            });
        };

        $scope.getStudents = function () {
            var promiseStudents = TicketService.getStudentsByBranchId(this.BranchId.BranchId);
            promiseStudents.then(function (response) {
                $scope.Students = response.data;
            }, function (error) {
            });
        };
        $scope.addTicket = function () {
            console.log('add method');
            var ticket = {
                Id: this.Id, ComplaintTypeId: this.ComplaintTypeId.ComplaintTypeId,
                StudentId: this.StudentId.StudentId, Description: this.Description, StatusId: this.StatusId.StatusId
            };

            var promiseAddEmployee = TicketService.post(ticket);
            promiseAddEmployee.then(function (ticket) {
                alert("Added successfully");
                $scope.Tickets.push(ticket.data);

            });


        };
        $scope.updateTicket = function () {
            var ticket = {
                Id: this.item.ID, ComplaintTypeId: this.item.ComplaintTypeId,
                StudentId: this.item.StudentId, Description: this.item.Description, ActionComments: this.item.ActionComments, StatusId: this.item.StatusId
            };
            var promiseUpdateEmployee = TicketService.put(this.item.ID, ticket);
            promiseUpdateEmployee.then(function (ticket) {
                alert("Updated successfully");
                //$scope.Employees.push(employee.data);

            }, function (error) {
                alert("error");
            });
        }
        $scope.deleteEmployee = function () {
            var empId = this.item.ID;
            var promiseDeleteEmployee = TicketService.delete(this.item.ID);
            promiseDeleteEmployee.then(function (pl) {
                alert("Employee Deleted Successfully.");
                removeEmployeeById(empId);
            },
                  function (errorPl) {
                      alert("error occured");
                  });
        };
        var removeEmployeeById = function (id) {
            for (var i = 0; i < $scope.Employees.length; i++) {
                if ($scope.Employees[i].ID == id) {
                    $scope.Employees.splice(i, 1);
                    break;
                }
            }
        };
    }]);
})();