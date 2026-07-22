import { CanDeactivateFn } from '@angular/router';

interface UnsavedChangesComponent {
  hasUnsavedChanges(): boolean;
}

function supportsUnsavedChanges(
  component: unknown,
): component is UnsavedChangesComponent {
  return (
    typeof component === 'object' &&
    component !== null &&
    'hasUnsavedChanges' in component &&
    typeof (
      component as UnsavedChangesComponent
    ).hasUnsavedChanges === 'function'
  );
}

export const unsavedChangesGuard:
  CanDeactivateFn<unknown> = (component) => {
    if (!supportsUnsavedChanges(component)) {
      return true;
    }

    if (!component.hasUnsavedChanges()) {
      return true;
    }

    return window.confirm(
      'You have unsaved changes. Leave?',
    );
  };