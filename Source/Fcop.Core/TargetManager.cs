using Fcop.Core.Commands;
using Fcop.Core.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fcop.Core
{
    public class TargetManager
    {
        private static List<ITarget> _loadedTargets = null;
        private static List<ICommand> _loadedCommands = null;
        private static List<IScanProcessor> _loadedScanProcessors = null;
        private static Dictionary<string, List<string>> _targetCommands = new Dictionary<string, List<string>>();
        private static object nspace;

        public static List<Type> GetTargetTypes()
        {
            var ret = new List<Type>();
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == "Fcop.Core.Targets" && typeof(ITarget).IsAssignableFrom(t) && typeof(TargetBase).IsAssignableFrom(t)
                    select t;

            q.ToList().ForEach(t => ret.Add(t));

            return ret;
        }

        public static List<Type> GetCommandTypes()
        {
            var ret = new List<Type>();

            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == "Fcop.Core.Commands" && typeof(ICommand).IsAssignableFrom(t)
                    select t;

            q.ToList().ForEach(t => ret.Add(t));

            return ret;
        }

        public static List<Type> GetScanProcessorTypes()
        {
            var ret = new List<Type>();

            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == "Fcop.Core.ScanProcessors" && typeof(IScanProcessor).IsAssignableFrom(t)
                    select t;

            q.ToList().ForEach(t => ret.Add(t));

            return ret;
        }

        public static List<ITarget> GetTargets()
        {
            LoadTargets();
            return _loadedTargets.OrderBy(x => x.Name).ToList();
        }

        private static void LoadScanProcessors()
        {
            if (_loadedScanProcessors != null)
                return;

            _loadedScanProcessors = new List<IScanProcessor>();
            var types = GetScanProcessorTypes();

            foreach (var targetType in types)
            {
                var targetInstance = (IScanProcessor)Activator.CreateInstance(targetType);
                _loadedScanProcessors.Add(targetInstance);
            }
        }

        private static void LoadTargets()
        {
            if (_loadedTargets != null)
                return;

            _loadedTargets = new List<ITarget>();
            var types = GetTargetTypes();

            foreach (var targetType in types)
            {
                var targetInstance = (ITarget)Activator.CreateInstance(targetType);
                _loadedTargets.Add(targetInstance);
            }
        }

        public static void LoadCommands()
        {
            if (_loadedCommands != null)
                return;

            _loadedCommands = new List<ICommand>();

            var types = GetCommandTypes();

            foreach (var commandType in types)
            {
                var cmdInstance = (ICommand)Activator.CreateInstance(commandType);

                bool noTargetAttributes = true;

                System.Reflection.MemberInfo info = commandType;
                object[] attributes = info.GetCustomAttributes(true);
                for (int i = 0; i < attributes.Length; i++)
                {
                    var attr = attributes[i] as Attributes.CommandTargetAttribute;
                    if (attr!=null)
                    {
                        noTargetAttributes = false;
                        if (attr.Any)
                        {
                            AddCommandToTarget(commandType.FullName);
                        } else if (attr.Namespaces!=null)
                        {
                            foreach(var ns in attr.Namespaces)
                                AddCommandToTarget(commandType.FullName, ns);
                        }
                    }
                }

                // No attributes == Any. Add this for all targets
                if (noTargetAttributes)
                    AddCommandToTarget(commandType.FullName);

                _loadedCommands.Add(cmdInstance);
            }
        }

        private static void AddCommandToTarget(string CommandFullTypeName, string TargetFullTypeName = null)
        {
            List<string> targetNames = new List<string>();
            if (TargetFullTypeName == null)
                _loadedTargets.ForEach(target => targetNames.Add(target.GetType().FullName));
            else
                targetNames.Add(TargetFullTypeName);

            foreach (var targetFullTypeName in targetNames)
            {
                if (!_targetCommands.ContainsKey(targetFullTypeName))
                    _targetCommands.Add(targetFullTypeName, new List<string>());

                if(!_targetCommands[targetFullTypeName].Contains(CommandFullTypeName))
                    _targetCommands[targetFullTypeName].Add(CommandFullTypeName);
            }

        }

        public static List<ICommand> GetCommands(Type TargetType)
        {
            LoadCommands();
            return _loadedCommands
                .Where(x => _targetCommands.ContainsKey(TargetType.FullName) && _targetCommands[TargetType.FullName].Contains(x.GetType().FullName))
                .OrderBy(x => x.Name)
                .ToList();
        }

        public static List<IScanProcessor> GetScanProcessors()
        {
            LoadScanProcessors();
            return _loadedScanProcessors
                .OrderBy(x => x.Name)
                .ToList();
        }

    }
}
