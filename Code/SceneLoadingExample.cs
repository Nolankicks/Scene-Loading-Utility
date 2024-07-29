using System.Linq;
using Microsoft.VisualBasic;
using Sandbox;
using SceneLoading;
public sealed class ChangeSceneTrigger : Component, Component.ITriggerListener
{
	[Property] public SceneFile sceneFile { get; set; }
	[Property] public GameObject PrefabTest { get; set; }

	void ITriggerListener.OnTriggerEnter( Sandbox.Collider other )
	{
		if ( other.GameObject.Tags.Has( "player" ) )
		{
			LoadScene();
		}
	}

	void ITriggerListener.OnTriggerExit( Sandbox.Collider other )
	{

	}

	public void LoadScene()
	{
		var customScene = new CustomScene( sceneFile );
		if ( customScene.GetAllObjectsByType( typeof( SkinnedModelRenderer ) ).Count() == 0 )
		{
			customScene.CreateObject( new GameObject() );
		}

		customScene.LoadScene();
	}
}
