using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using Infrastructure;

namespace CodeBase.Infrastructure {
    public class Game {
        public GameStateMachine StateMachine;
        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain){
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain, AllServices.Container);
        }
    }
}