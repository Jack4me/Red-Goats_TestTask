using CodeBase.Infrastructure.States;
using Infrastructure;
using Infrastructure.Services;

namespace CodeBase.Infrastructure {
    public class Game {
        public GameStateMachine StateMachine;
        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain){
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain, AllServices.Container);
        }
    }
}