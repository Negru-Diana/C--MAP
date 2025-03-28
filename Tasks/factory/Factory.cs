using Lab10.containers;

namespace Lab10.factory;

public interface Factory
{
    Container createContainer(ContainerStrategy strategy);
}