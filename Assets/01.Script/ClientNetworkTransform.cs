using Unity.Netcode.Components;

public class ClientNetworkTransform : NetworkTransform
{

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        CanCommitToTransform = IsOwner; //�����ڴ� ������ �����ϰ�
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
                //�׷� ������ �ڽ��� transform�� ����ð����� ����ȭ�� �õ��Ѵ�. 
                //�ð��� �ָ� interpolate�� �����ϴ�.

                TryCommitTransformToServer(transform, NetworkManager.LocalTime.Time);
            }

        }
    }

}
