# TaskFlow API Design

## Projects
| Verb | URL | Purpose | Success | Errors | Idempotent? |
|------|-----|---------|---------|--------|-------------|
| GET | /api/projects | List projects | 200 | 401 | Yes |
| GET | /api/projects/{id} | Get one project | 200 | 401, 404 | Yes |
| POST | /api/projects | Create project | 201 + Location header | 400, 401, 403 | No |
| PUT | /api/projects/{id} | Update project | 204 | 400, 401, 403, 404 | Yes |
| DELETE | /api/projects/{id} | Delete project | 204 | 401, 403, 404 | Yes |

## Tasks
| Verb | URL | Purpose | Success | Errors | Idempotent? |
|------|-----|---------|---------|--------|-------------|
| GET | /api/projects/{projectId}/tasks | List tasks in a project | 200 | 401, 404 | Yes |
| GET | /api/tasks/{id} | Get one task | 200 | 401, 404 | Yes |
| POST | /api/projects/{projectId}/tasks | Create task | 201 + Location header | 400, 401, 403, 404 | No |
| PUT | /api/tasks/{id} | Update task | 204 | 400, 401, 403, 404 | Yes |
| PATCH | /api/tasks/{id}/status | Update task status | 204 | 400, 401, 403, 404 | Yes |
| DELETE | /api/tasks/{id} | Delete task | 204 | 401, 403, 404 | Yes |

## Comments
| Verb | URL | Purpose | Success | Errors | Idempotent? |
|------|-----|---------|---------|--------|-------------|
| GET | /api/tasks/{taskId}/comments | List comments of a task | 200 | 401, 404 | Yes |
| POST | /api/tasks/{taskId}/comments | Add comment | 201 + Location header | 400, 401, 403, 404 | No |
| PATCH | /api/comments/{id}/resolve | Mark comment as resolved | 204 | 401, 403, 404 | Yes |

## Design decisions
1. POST /api/projects/3/tasks returns 201 Created, with a Location header pointing to the new task (/api/tasks/{id}) and the created task in the body.
2. A Member deleting someone else's task gets 403 Forbidden: the user is logged in (so not 401) but not allowed to do it.
3. A request for a task that doesn't exist returns 404 Not Found.
4. PUT replaces the whole resource. PATCH updates only some fields, such as a task's status or a comment's resolved flag.
5. Only a Manager can resolve a comment.