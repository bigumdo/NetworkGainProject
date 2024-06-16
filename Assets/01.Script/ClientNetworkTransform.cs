using Unity.Netcode.Components;

public class ClientNetworkTransform : NetworkTransform
{

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        CanCommitToTransform = IsOwner; //소유자는 변경이 가능하게
    }

    protected override bool OnIsServerAuthoritative()
    {
        return false;
    }

    protected override void Update()
    {
        CanCommitToTransform = IsOwner;
        base.Update();
        if(NetworkManager.IsConnectedClient||NetworkManager.IsListening)
        {
            if (CanCommitToTransform)
            {
                //그럼 서버로 자신의 transform과 현재시간으로 동기화를 시도한다. 
                //시간을 주면 interpolate가 가능하다.

                TryCommitTransformToServer(transform, NetworkManager.LocalTime.Time);
            }

        }
    }

}
