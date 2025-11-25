http://localhost:5182/ProjectManager/Update/1


An unhandled exception occurred while processing the request.
InvalidOperationException: The instance of entity type 'Project' cannot be tracked because another instance with the same key value for {'Id'} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using 'DbContextOptionsBuilder.EnableSensitiveDataLogging' to see the conflicting key values.
Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap<TKey>.ThrowIdentityConflict(InternalEntityEntry entry)

Stack Query Cookies Headers Routing
InvalidOperationException: The instance of entity type 'Project' cannot be tracked because another instance with the same key value for {'Id'} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using 'DbContextOptionsBuilder.EnableSensitiveDataLogging' to see the conflicting key values.
Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap<TKey>.ThrowIdentityConflict(InternalEntityEntry entry)
Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap<TKey>.Add(TKey key, InternalEntityEntry entry, bool updateDuplicate)
Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap<TKey>.Add(TKey key, InternalEntityEntry entry)
Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap<TKey>.Add(InternalEntityEntry entry)
Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, bool acceptChanges, bool modifyProperties)
Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState entityState, bool acceptChanges, bool modifyProperties, Nullable<EntityState> forceStateWhenUnknownKey, Nullable<EntityState> fallbackState)
Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode<ValueTuple<EntityState, EntityState, bool>> node)
Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph<TState>(EntityEntryGraphNode<TState> node, Func<EntityEntryGraphNode<TState>, bool> handleNode)
Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, bool forceStateWhenUnknownKey)
Microsoft.EntityFrameworkCore.Internal.InternalDbSet<TEntity>.SetEntityState(InternalEntityEntry entry, EntityState entityState)
Microsoft.EntityFrameworkCore.Internal.InternalDbSet<TEntity>.Update(TEntity entity)
PIS.Repositories.ProjectRepository.Update(Project project) in ProjectRepository.cs
+
        _context.Projects.Update(project);
PIS.Services.ProjectManager.Update(Project project) in ProjectManager.cs
+
            _repository.Update(project);
PIS.Controllers.ProjectManagerController.Update(Project project) in ProjectManagerController.cs
+
            var ok = _projectService.Update(project);
lambda_method74(Closure , object , object[] )
Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor+SyncActionResultExecutor.Execute(ActionContext actionContext, IActionResultTypeMapper mapper, ObjectMethodExecutor executor, object controller, object[] arguments)
Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeActionMethodAsync()
Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(ref State next, ref Scope scope, ref object state, ref bool isCompleted)
Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeNextActionFilterAsync()
Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Rethrow(ActionExecutedContextSealed context)
Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(ref State next, ref Scope scope, ref object state, ref bool isCompleted)
Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()
Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeNextResourceFilter>g__Awaited|25_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, object state, bool isCompleted)
Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.Rethrow(ResourceExecutedContextSealed context)
Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.Next(ref State next, ref Scope scope, ref object state, ref bool isCompleted)
Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.InvokeFilterPipelineAsync()
Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)
Microsoft.AspNetCore.Authentication.AuthenticationMiddleware.Invoke(HttpContext context)
Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddlewareImpl.Invoke(HttpContext context)

Show raw exception details