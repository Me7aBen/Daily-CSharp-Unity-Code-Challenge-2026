Día 1 — Observer Pattern con Events

## 🟢 Fácil (~5 min)

Creá una clase `Health` que tenga un `event Action<float> OnHealthChanged`. Cuando la vida cambie, el evento se dispara. Un `HealthBarUI` se suscribe y logea el valor nuevo.

## 🟡 Media (~15 min)

Extendé: agregá `event Action OnDied`. Creá 3 suscriptores distintos (`ScoreManager`, `UIManager`, `SoundManager`) que reaccionen a la muerte. Asegurate de desuscribirte en `OnDisable()`.

## 🔴 Difícil (~20 min)

Implementá un `EventBus` estático genérico con `Subscribe<T>(Action<T>)`, `Publish<T>(T data)`, `Unsubscribe<T>()`. Creá eventos custom como `PlayerDiedEvent`, `EnemySpawnedEvent { int count }`. Demostrá comunicación entre sistemas que no se referencian.

---

## 💡 Hints

- `event Action<T>` es la forma más simple de Observer en C#
- Siempre desuscribite en `OnDisable()` o `OnDestroy()`
- `?.Invoke()` para null-safe invocation
- Para el EventBus: `Dictionary<Type, Delegate>`

**Repasar**: [C# Events](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/events/) | [Game Programming Patterns - Observer](https://gameprogrammingpatterns.com/observer.html)

---

## ✅ Criterios de Aceptación

- [ ]  Al llamar `TakeDamage()`, todos los suscriptores reciben el nuevo valor
- [ ]  Al morir, se dispara `OnDied` y todos los suscriptores reaccionan
- [ ]  Si destruís un suscriptor, no hay NullReferenceException al disparar
- [ ]  (Difícil) Dos sistemas se comunican sin referenciarse directamente