// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the
// Error List, point to "Suppress Message(s)", and click
// "In Project Suppression File".
// You do not need to add suppressions to this file manually.


[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.Interop.NativeColorRef.#set_Dword(System.UInt32)")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.PreviewHandler.#Microsoft.WindowsAPICodePack.ShellExtensions.Interop.IPreviewHandler.DoPreview()")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.WpfPreviewHandler.#Initialize()")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1805:DoNotInitializeUnnecessarily", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.ThumbnailProvider.#.ctor()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1805:DoNotInitializeUnnecessarily", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.WpfPreviewHandler.#.ctor()")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "API")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Scope = "namespace", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.Interop", MessageId = "API")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Scope = "namespace", Target = "Microsoft.WindowsAPICodePack.ShellExtensions", MessageId = "API")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.PreviewHandler.#SetBackground(System.Int32)", MessageId = "argb")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.PreviewHandler.#SetForeground(System.Int32)", MessageId = "argb")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Scope = "type", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.IThumbnailFromStream")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Scope = "type", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.IPreviewFromStream")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.ThumbnailProvider.#System.Runtime.InteropServices.ICustomQueryInterface.GetInterface(System.Guid&,System.IntPtr&)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.PreviewHandler.#System.Runtime.InteropServices.ICustomQueryInterface.GetInterface(System.Guid&,System.IntPtr&)")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1014:MarkAssembliesWithClsCompliant")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.ThumbnailProvider.#GetThumbnailAlphaType()")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "API")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "API", Scope = "namespace", Target = "Microsoft.WindowsAPICodePack.ShellExtensions")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "API", Scope = "namespace", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.Interop")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Scope = "type", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.IPreviewFromStream")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Scope = "type", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.IThumbnailFromStream")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.PreviewHandlers.PreviewHandler.#Microsoft.WindowsAPICodePack.ShellExtensions.Interop.IPreviewHandler.DoPreview()", Justification = "Exception is handled later")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.PreviewHandler.#Microsoft.WindowsAPICodePack.ShellExtensions.Interop.IPreviewHandler.DoPreview()", Justification = "Exception is handled later")]

// All link demand related warnings suppressed.
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.ThumbnailProvider.#Microsoft.WindowsAPICodePack.ShellExtensions.Interop.IThumbnailProvider.GetThumbnail(System.UInt32,System.IntPtr&,System.UInt32&)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.WpfPreviewHandler.#Initialize()")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Justification = "Interfaces are implemented explicitly because they are native COM interfaces, we do not want child types to call them.", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.ThumbnailProvider.#System.Runtime.InteropServices.ICustomQueryInterface.GetInterface(System.Guid&,System.IntPtr&)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Justification = "Interfaces are implemented explicitly because they are native COM interfaces, we do not want child types to call them.", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.PreviewHandler.#System.Runtime.InteropServices.ICustomQueryInterface.GetInterface(System.Guid&,System.IntPtr&)")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1014:MarkAssembliesWithClsCompliant", Justification = "There are places where unsigned values are used, which is considered not Cls compliant.")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Justification = "Populated via marshaling.", Target = "Microsoft.WindowsAPICodePack.ShellExtensions.Interop.NativeColorRef.#Dword")]


[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "API")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Scope = "namespace", Target = "Microsoft.WindowsAPICodePack.Sensors", MessageId = "API")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.SensorTypes.#RfidScanner", MessageId = "Rfid", Justification = "False positives")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.SensorTypes.#MultivalueSwitch", MessageId = "Multivalue", Justification = "False positives")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.SensorTypes.#Gyrometer3D", MessageId = "Gyrometer", Justification = "False positives")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.SensorTypes.#LocationGps", MessageId = "Gps", Justification = "False positives")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.SensorTypes.#Gyrometer2D", MessageId = "Gyrometer", Justification = "False positives")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.SensorTypes.#Gyrometer1D", MessageId = "Gyrometer", Justification = "False positives")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.SensorPropertyKeys.#SensorDataTypeSatellitesInViewPrns", MessageId = "Prns", Justification = "False positives")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.SensorPropertyKeys.#SensorDataTypeLightLux", MessageId = "Lux", Justification = "False positives")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.SensorPropertyKeys.#SensorDataTypeSatellitesUsedPrns", MessageId = "Prns", Justification = "False positives")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.SensorPropertyKeys.#SensorDataTypeForceNewtons", MessageId = "Newtons", Justification = "False positives")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.SensorPropertyKeys.#SensorDataTypeSatellitesInViewStnRatio", MessageId = "Stn", Justification = "False positives")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.SensorPropertyKeys.#SensorDataTypeRfidTag40Bit", MessageId = "Rfid", Justification = "False positives")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.SensorPropertyKeys.#SensorDataTypeMultivalueSwitchState", MessageId = "Multivalue", Justification = "False positives")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.SensorManager.#GetSensorsByTypeId`1()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.SensorManager.#GetSensorBySensorId`1(System.Guid)")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1014:MarkAssembliesWithClsCompliant", Justification = "There are places where unsigned values are used, which is considered not Cls compliant.")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Scope = "member", Justification = "Returns a new instance of an object.", Target = "Microsoft.WindowsAPICodePack.Sensors.Sensor.#GetSupportedProperties()")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Scope = "type", Target = "Microsoft.WindowsAPICodePack.Sensors.SensorList`1")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Scope = "type", Target = "Microsoft.WindowsAPICodePack.Sensors.SensorData")]

#region LinkDemand related
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.Sensor.#GetInterestingEvents()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.Sensor.#GetProperties(System.Int32[])")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.Sensor.#GetProperties(Microsoft.WindowsAPICodePack.Shell.PropertySystem.PropertyKey[])")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.Sensor.#GetProperty(Microsoft.WindowsAPICodePack.Shell.PropertySystem.PropertyKey)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.Sensor.#GetSupportedProperties()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.Sensor.#InternalUpdateData()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.Sensor.#SetEventInterest(System.Guid)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.Sensor.#SetProperties(Microsoft.WindowsAPICodePack.Sensors.DataFieldInfo[])")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.Sensor.#UpdateData()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.Sensors.SensorData.#FromNativeReport(Microsoft.WindowsAPICodePack.Sensors.ISensor,Microsoft.WindowsAPICodePack.Sensors.ISensorDataReport)")]
#endregion


[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "API")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Scope = "namespace", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices", MessageId = "API")]


[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.MappingAvailableServices.#TransliterationDevanagariToLatin", MessageId = "Devanagari")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.MappingAvailableServices.#TransliterationHantToHans", MessageId = "Hant")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.MappingAvailableServices.#TransliterationHansToHant", MessageId = "Hant")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1014:MarkAssembliesWithClsCompliant", Justification = "There are places where unsigned values are used, which is considered not Cls compliant.")]

#region LinkDemand related
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.InteropTools.#Free`1(System.IntPtr&)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.InteropTools.#Pack`1(!!0&)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.InteropTools.#Unpack`1(System.IntPtr)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.InteropTools.#UnpackStringArray(System.IntPtr,System.UInt32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.LinguisticException.#.ctor()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.LinguisticException.#.ctor(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.LinguisticException.#.ctor(System.String,System.Exception)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.LinguisticException.#.ctor(System.UInt32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.MappingDataRange.#GetData()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.MappingPropertyBag.#Dispose(System.Boolean)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.MappingPropertyBag.#.ctor(Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.MappingOptions,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.MappingService.#GetServices(Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.MappingEnumOptions)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.MappingService.#.ctor(System.Guid)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.MappingService.#RecognizeText(System.String,System.Int32,System.Int32,Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.MappingOptions)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.ServiceCache.#RollBack(System.IntPtr,System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.ServiceCache.#TryRegisterServices(System.IntPtr,System.IntPtr[],System.Boolean&)")]

#endregion

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Scope = "type", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.ServiceCache")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.MappingService.#EndDoAction(Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.MappingActionAsyncResult)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Scope = "member", Target = "Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.MappingService.#EndRecognizeText(Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.MappingRecognizeAsyncResult)")]
