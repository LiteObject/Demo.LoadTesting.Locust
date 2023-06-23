"""Module docstring"""
from locust import HttpUser, task, between


class WebsiteUser(HttpUser):
    """Class representing a websiteuser"""
    wait_time = between(1, 5)

    @task
    def values_endpoint(self):
        """Function printing python version."""
        self.client.verify = False
        self.client.get(url="/api/values")

    @task
    def values_slow_endpoint(self):
        """Function printing python version."""
        self.client.verify = False
        self.client.get(url="/api/values/slow")
