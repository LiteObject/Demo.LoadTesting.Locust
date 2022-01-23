import time
from locust import HttpUser, task, between

# http://docs.locust.io/en/stable/quickstart.html
class WebsiteUser(HttpUser):
	wait_time = between(1, 5)

	@task
	def fast_endpoint(self):
		self.client.verify = False
		self.client.get(url="/")

	@task
	def	slow_endpoint(self):
		self.client.verify = False
		self.client.get(url="/slow")